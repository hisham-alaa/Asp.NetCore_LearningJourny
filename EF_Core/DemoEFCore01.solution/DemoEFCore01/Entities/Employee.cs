using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore01.Entities
{

    ///POCO Class(Plain Old Clr Object)
    ///No Functionality just representation for the table in the DB 

    ///1. This Class Created By Convention (The Easiest way to do mapping)
    ///class Employee
    ///{
    ///    public int Id { get; set; }//Public numeric Value with name Id or ClassnameID is the pk with identity constraint
    ///    public string? Name { get; set; }//Nullable Reference Type [Optional]
    ///    public double Salary { get; set; }//[Required]
    ///    public int? Age { get; set; }//Nullable<int> [Optional]
    ///    public string? Address { get; set; }
    ///
    ///}

    ///2. This Class Created By Data Annotation (Used to validate in mvc project in front and back end or general validation)
    [Table("Employees",Schema="dbo")]
    class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity/*None-Computed(Will Generaated in the DB)*/)]
        public int EmpId { get; set; }
        
    
        [Required/*AllowNull*/]
        [Column(TypeName ="varchar")]
        ///[MaxLength(50)]
        [StringLength(50,MinimumLength =20)]
        public string? Name { get; set; }
    
    
        [DataType(DataType.Currency)]
        [Column(TypeName="money")]//is that valid?
        public double Salary { get; set; }
    
    
        [Range(22,60)]//for numbers
        public int? Age { get; set; }
    
    
        [NotMapped]//will not mapped to the database just for the Application
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    
    
        [NotMapped]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    
    
        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int? DepartmentDeptId { get; set; }

        //[ForeignKey("Dept")]
        [InverseProperty("Employees")]
        public Department Department { get; set; }
    }

}