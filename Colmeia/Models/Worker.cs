using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colmeia.Models
{
    public class Worker
    {
        public string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        public string Nome { get; set; }
        public int Id { get; set; }

         public Worker(){}

        public Worker(string[] jobsICanDo, string nome, int id)
        {
            this.jobsICanDo = jobsICanDo;
            this.Id = id;
            this.Nome = nome;

        }
         public Worker(string nome, int id)
         {
             this.Id = id;
             this.Nome = nome;
             this.jobsICanDo = new string[1];
         }

        public int ShiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        private string currentJob = "";

        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }

        public bool DoThisJob(string job, int numberOfShifts)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;
            for(int i = 0; i <jobsICanDo.Length; i++)
                if (jobsICanDo[i] == job)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                }
            return false;
        }

        public bool WorkOneShift()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;

            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            else
                return false;
        }
    }
}