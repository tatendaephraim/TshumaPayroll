using System.ComponentModel.DataAnnotations;

namespace TshumaPayroll.Models
{
    public class Salary
    {
        private decimal netPay;
        private decimal totalDeductions;
        private decimal totalAllowances;
        private decimal grossSalary;
        private decimal payee;

        [Key]
        public int SalaryId { get; set; }

        [Display(Name = "Net Salary")]
        [DataType(DataType.Currency)]
        public decimal NetPay
        {
            get { return netPay; }
            set
            {
                totalDeductions = Payee + NSSAPensions;
                netPay = GrossSalary - totalDeductions;
                netPay = value;
            }
        }


        [Display(Name = "Gross Salary ")]
        [DataType(DataType.Currency)]
        public decimal GrossSalary
        {
            get { return grossSalary; }
            set
            {
                totalAllowances = TransportAllowance + MedicalAid + FuneralCover;
                grossSalary = basicSalary + totalAllowances;
                grossSalary = value;
            }
        }


        //Allowances
        [Display(Name = "Medical Aid (CIMAS)")]
        [DataType(DataType.Currency)]
        public decimal MedicalAid { get; set; } = 1500m;

        [Display(Name = "Transport Allowance ")]
        [DataType(DataType.Currency)]
        public decimal TransportAllowance { get; set; } = 3000m;

        [Display(Name = "Payee")]
        [DataType(DataType.Currency)]
        public decimal Payee
        {
            get { return payee; }
            set
            {
                payee = NetPay * 5 / 100; //5% OF net pay
                payee = value;
            }
        }


        [Display(Name = "NSSA Pensions Contributions ")]
        [DataType(DataType.Currency)]
        public decimal NSSAPensions { get; set; } = 3000m;

        [Display(Name = "Funeral Cover(Nyaradzo)")]
        [DataType(DataType.Currency)]
        public decimal FuneralCover { get; set; } = 2000;

        //Basic Salary is set based on the Employee Grade
        private decimal basicSalary;

        [Display(Name = "Basic Salary")]
        [DataType(DataType.Currency)]
        public decimal BasicSalary
        {
            get { return basicSalary; }
            set
            {

                Employee employee = new Employee();
                switch (employee.Grade)
                {
                    case SalaryGrade.One:
                        basicSalary = 54000m;
                        break;
                    case SalaryGrade.Two:
                        basicSalary = 50000m;
                        break;
                    case SalaryGrade.Three:
                        basicSalary = 40000m;
                        break;
                    case SalaryGrade.Four:
                        basicSalary = 20000m;
                        break;
                    case SalaryGrade.Five:
                        basicSalary = 15000m;
                        break;
                    case SalaryGrade.Six:
                        basicSalary = 54000m;
                        break;
                    default:
                        break;
                }
                basicSalary = value;
            }
        }

        [Display(Name = "Salary Month")]
        public Month SalaryMonth { get; set; }



        //Navigation Properties

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
    public enum Month
    {
        January, February, March, April, May, June, July, August, September, October, November, December
    }
}
