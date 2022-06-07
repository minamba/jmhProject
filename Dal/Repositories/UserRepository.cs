using Google.Cloud.Firestore;
using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Dal.Extensions;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"quizz-jmh-firebase.json";
        private static FirestoreDb db = FirestoreDb.Create("quizz-jmh");

        public UserRepository() => Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

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
                    UserDto u = new UserDto();
                    u.Id = docsnap.Id;
                    u.FirstName = user.FirstName;
                    u.LastName = user.LastName;
                    u.Pseudonym = user.Pseudonym;
                    u.Mail = user.Mail;
                    u.LevelId = user.LevelId;
                    u.Sexe = user.Sexe;
                    u.Password = user.Password;

                    lstUsers.Add(u);
                }
            }
            return lstUsers.ToUser();
        }
    }
}
