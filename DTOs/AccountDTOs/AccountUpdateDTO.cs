using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AccountDTOs
{
   public class AccountUpdateDTO
    {
        public int SenderID { get; set; }
        public int ReceiveID { get; set; }

        public decimal Balance { get; set; }
        

    }
}
