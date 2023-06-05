using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
        { }

        //protected override void Verify(SecurityLoginsRolePoco[] pocos)
        //{

        //    foreach (var poco in pocos)
        //    {

        //        List<ValidationException> errors = new List<ValidationException>();


        //        if (poco.CurrentSalary < 0)
        //        {
        //            errors.Add(new ValidationException(111, "CurrentSalary cannot be negative"));

        //        }

        //        if (poco.CurrentRate < 0)
        //        {
        //            errors.Add(new ValidationException(112, "CurrentRate cannot be negative"));


        //        }

        //        if (errors.Count > 0)
        //        {
        //            throw new AggregateException(errors);
        //        }
        //    }

        //}

        public override void Add(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }


    }
}
