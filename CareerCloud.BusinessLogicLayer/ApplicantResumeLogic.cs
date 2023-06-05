﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
    {
        public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository) 
        { }

        protected override void Verify(ApplicantResumePoco[] pocos)
        {

            foreach (var poco in pocos)
            {

                List<ValidationException> errors = new List<ValidationException>();


                if (string.IsNullOrEmpty(poco.Resume))
                {
                    errors.Add(new ValidationException(113, "Resume cannot be empty"));

                }

                

                if (errors.Count > 0)
                {
                    throw new AggregateException(errors);
                }
            }

        }

        public override void Add(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

    }
}
