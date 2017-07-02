using finview.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using finview.Entities.Model;
using finview.DataAccess.Data;

namespace finview.DataAccess
{
    public class FileImportRepository : IFileImportRepository
    {

        public FileUploadTrack InitiateImport()
        {
            FileUploadTrack fut = new FileUploadTrack();
            using (FinViewModel fvm = new FinViewModel())
            {
                fut.Status = ImportStatus.Inprogress;
                fut.UploadDate = DateTime.Now;
                fvm.Set<FileUploadTrack>().Add(fut);
                fvm.SaveChanges();
            }
            return fut;
        }

        public List<Transactions> ReadTransactions(string fileName, FileUploadTrack fut)
        {
            List<Transactions> result = new List<Transactions>();

            using (TextFieldParser csvParser = new TextFieldParser(fileName))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { " ," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    var trans = new Transactions();

                    trans.FileUploadTrackId = fut.Id;

                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    DateTime dt;
                    if (DateTime.TryParse(fields[0], out dt))
                    {
                        trans.TransactionDate = dt;
                    }

                    trans.Narration = fields[1];

                    if (DateTime.TryParse(fields[2], out dt))
                    {
                        trans.TransactionValueDate = dt;
                    }
                    decimal curr;
                    if (decimal.TryParse(fields[3], out curr))
                    {
                        trans.WithdrawalAmount = curr;
                    }

                    if (decimal.TryParse(fields[4], out curr))
                    {
                        trans.DepositAmount = curr;
                    }

                    trans.ChequeNumer = fields[5];

                    if (decimal.TryParse(fields[6], out curr))
                    {
                        trans.ClosingBalance = curr;
                    }

                    result.Add(trans);
                }
            }

            return result;
        }

        public void SaveFileUploadTrack(FileUploadTrack fut)
        {
            using (FinViewModel fvm = new FinViewModel())
            {
                if(fut.Id == 0)
                {
                    fvm.Set<FileUploadTrack>().Add(fut);
                }
                else
                {
                    if(fvm.Entry(fut).State == System.Data.Entity.EntityState.Detached)
                    {
                        fvm.Set<FileUploadTrack>().Attach(fut);
                    }
                }

                fut.Status = ImportStatus.Uploaded;

                fvm.SaveChanges();
            }
        }
    }
}
