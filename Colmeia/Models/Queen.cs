using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colmeia.Models
{
    public class Queen
    {
        public List<Worker> workers;
        private int shiftNumber = 0;
        public int id;

        public Queen(List<Worker> workers)
        {
            this.workers = workers;
        }
               
        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Count; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumber++;
            string report = "Relatório para turno #" + shiftNumber +"\n";
            for (int i = 0; i < workers.Count; i++)
            {
                if(workers[i].WorkOneShift())
                    report += "Operária #" + (i + 1) + "terminou o trabalho\r\n";
                else
                    if(workers[i].ShiftsLeft > 0)
                        report += "Operária #" + (i + 1) + "fará ' " + workers[i].CurrentJob
                            +"' por " + workers[i].ShiftsLeft + "mais turnos\r\n";
                    else 
                        report += "Operária #" + (i + 1) + " terminará  '"
                            + workers[i].CurrentJob + "' após este turno\r\n";
            }
            return report;
        }

    }
}