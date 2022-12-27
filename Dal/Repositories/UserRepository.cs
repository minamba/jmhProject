using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Dal.Extensions;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"/Firebase/quizz-jmh-firebase.json";
        private static FirestoreDb db = FirestoreDb.Create("quizz-jmh");

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            List<UserDto> lstUsers = new List<UserDto>();
            Query docRef = db.Collection("User");
            QuerySnapshot snap = await docRef.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                UserDto user = docsnap.ConvertTo<UserDto>();

                if (docsnap.Exists)
                {
                    lstUsers.Add(ReadDatas(docsnap));
                }
            }
            return lstUsers.ToUser();
            //return lstUsers.OrderBy(u => u.FirstName).ToUser();
        }

        public async Task<User> GetUserByIdUserAsync(string id)
        {
            DocumentReference docref = db.Collection("User").Document(id);
            DocumentSnapshot snap = await docref.GetSnapshotAsync();

            return ReadDatas(snap).ToUser();
        }

        //AddUserWithAutoId
        public async Task<User> AddUserAsync(User user)
        {
            //Add IdentityUser
            var idenityUser = new IdentityUser()
            {
                Email = user.Mail,
                UserName = user.Mail,
            };

            IdentityResult result = await _userManager.CreateAsync(idenityUser, user.Password);

            if(result.Succeeded)
            {
                // Add firestore user
                //CollectionReference coll = db.Collection("User"); //Add document with autoID
                DocumentReference doc = db.Collection("User").Document(idenityUser.Id); //Add document with custom id
                Dictionary<string, object> data = new Dictionary<string, object>()
                {
                    {"FirstName", user.FirstName},
                    { "LastName", user.LastName},
                    { "LevelId",user.LevelId},
                    { "Mail",user.Mail},
                    { "Password",user.Password},
                    { "Pseudonym",user.Pseudonym},
                    { "Sexe",user.Sexe}
                };

                UserDto userToReturn = new UserDto();
                userToReturn.FirstName = user.FirstName;
                userToReturn.LastName = user.LastName;
                userToReturn.LevelId = user.LevelId;
                userToReturn.Mail = user.Mail;
                userToReturn.Password = user.Password;
                userToReturn.Pseudonym = user.Pseudonym;
                userToReturn.Sexe = user.Sexe;

                doc.SetAsync(data);
           
                return userToReturn.ToUser();
            }
            else
                return null;
        }


        //The method UpdateAsync allow us to update specifics fields
        public async Task<User> UpdateUserAsync(string id, User user)
        {
            //Identity user
            IdentityUser IdtUser = await _userManager.FindByIdAsync(id);

            if (IdtUser != null)
            {
                IdtUser.UserName = user.Mail;
                IdtUser.Email = user.Mail;
                IdtUser.NormalizedUserName = user.Mail;
                IdtUser.NormalizedEmail = user.Mail;
                
                    //Firestore user
                    DocumentReference docref = db.Collection("User").Document(id);
                    Dictionary<string, object> data = new Dictionary<string, object>()
                    {
                        { "FirstName", user.FirstName },
                        { "LastName", user.LastName },
                        { "Pseudonym", user.Pseudonym },
                        { "Mail", user.Mail },
                        { "Sexe", user.Sexe },
                        { "LevelId", user.LevelId },
                    };

                    DocumentSnapshot snap = await docref.GetSnapshotAsync();
                    if (snap.Exists)
                    {
                        await _userManager.UpdateAsync(IdtUser);
                        await docref.UpdateAsync(data);

                        return ReadDatas(snap).ToUser();
                    }
            }
            else
                return null;

            return null;
        }



        public async Task<User> DeleteUserAsync(string id)
        {
            IdentityUser idtUser = await _userManager.FindByIdAsync(id);

            if(idtUser != null)
            {
                DocumentReference docref = db.Collection("User").Document(id);
                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    await _userManager.DeleteAsync(idtUser);
                    docref.DeleteAsync();
                    return ReadDatas(snap).ToUser();
                }
            }
            else
                return null;

            return null;
        }

        public Task<User> ReplaceAllUserFieldsAsync(string id)
        {
            throw new NotImplementedException();
        }


        //This method replace all field of an user. So, in the dictionnary you have must to update all the fields with the method 'UpdateAsync'
        //If i change just one field, it will delete all the others fields from the object
        //public async Task<User> ReplaceAllUserFieldsAsync(string id)
        //{
        //    DocumentReference docref = db.Collection("User").Document(id);
        //    Dictionary<string, object> data = new Dictionary<string, object>()
        //    {
        //        {"FirstName","Arnaud" },
        //        {"LastName","Alcindor" },
        //        {"Level_Id","MLNBdY8E6LhZ6LWiJbHh" },
        //        {"Mail","minamba.c@gmail.com" },
        //        {"Password","123" },
        //        {"Pseudonym","Arn" },
        //        {"Sexe","Homme" },

        //    };

        //    DocumentSnapshot snap = await docref.GetSnapshotAsync();
        //    if (snap.Exists)
        //        await docref.SetAsync(data);

        //    UserDto user = snap.ConvertTo<UserDto>();
        //    UserDto u = new UserDto();
        //    u.Id = snap.Id;
        //    u.FirstName = user.FirstName;
        //    u.LastName = user.LastName;
        //    u.Pseudonym = user.Pseudonym;
        //    u.Mail = user.Mail;
        //    u.LevelId = user.LevelId;
        //    u.Sexe = user.Sexe;
        //    u.Password = user.Password;

        //    return u.ToUser();
        //}


        private UserDto ReadDatas(DocumentSnapshot snap)
        {
            UserDto user = snap.ConvertTo<UserDto>();

            if (snap.Exists)
            {
                UserDto u = new UserDto();
                u.Id = snap.Id;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Pseudonym = user.Pseudonym;
                u.Mail = user.Mail;
                u.LevelId = user.LevelId;
                u.Sexe = user.Sexe;
                u.Password = user.Password;

                return u;
            }
            return null;
        }
    }
}
