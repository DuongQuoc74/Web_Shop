using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace eShopsolutin.Data.Entities
{
    public class Transaction // giao dịch
    {
        public int Id { set; get; }
        public DateTime TransactionDate { set; get; }// ngày giao dịch
        public string ExternalTransactionId { set; get; }// id giao dịch bên ngoài
        public decimal Amount { set; get; } // lượng
        public decimal Fee { set; get; }// phí
        public string Result { set; get; }//kết quả
        public string Message { set; get; }// thông điệp
        public TransactionStatus Status { set; get; }
        public string Provider { set; get; }//cung cấp

        public Guid UserId { set; get; }
        public AppUser AppUser { set; get; }   
        
    }
}
