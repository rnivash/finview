using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finview.Entities.Model
{
    public class Transactions
    {
        public DateTime TransactionDate { get; set; }

        public DateTime? TransactionValueDate { get; set; }
        
        public string Narration { get; set; }

        public string ChequeNumer { get; set; }

        public decimal? WithdrawalAmount { get; set; }

        public decimal? DepositAmount { get; set; }

        public decimal? ClosingBalance { get; set; }

        public string Category { get; set; }

        public byte[] posted_at { get; set; }

        public long FileUploadTrackId { get; set; }

        public virtual FileUploadTrack FileUploadTrack { get; set; }
    }
}
