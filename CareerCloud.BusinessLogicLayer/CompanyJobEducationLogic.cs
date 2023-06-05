﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository) 
        { }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {

            foreach (var poco in pocos)
            {

                List<ValidationException> errors = new List<ValidationException>();


                if (poco.Major?.Length < 2)
                {
                    errors.Add(new ValidationException(200, "Major must be at least 2 characters"));

                }

                if (poco.Importance < 0)
                {
                    errors.Add(new ValidationException(201, "Importance cannot be less than 0"));


                }

                if (errors.Count > 0)
                {
                    throw new AggregateException(errors);
                }
            }

        }

        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

    }
}
