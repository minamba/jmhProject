﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Interfaces.Repositories
{
    public interface IClientApplicationRepository
    {
        Task CreateApplicationClient();
    }
}
