using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.Entities.Model
{
    public class FileUploadTrack
    {
        public FileUploadTrack()
        {
            this.Transactions = new HashSet<Transactions>();
        }
        public long Id { get; set; }

        public DateTime UploadDate { get; set; }

        public ImportStatus Status { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
