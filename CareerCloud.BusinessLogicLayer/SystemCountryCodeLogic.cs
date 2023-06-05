﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;

        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
            _repository= repository;
        }

        protected virtual void Verify(SystemCountryCodePoco[] pocos)
        {
            foreach (var poco in pocos)
            {

                List<ValidationException> errors = new List<ValidationException>();


                if (string.IsNullOrEmpty(poco.Name))
                {
                    errors.Add(new ValidationException(901, "Cannot be empty"));

                }

                if (string.IsNullOrEmpty(poco.Code))
                {
                    errors.Add(new ValidationException(900, "Cannot be empty"));

                }


                if (errors.Count > 0)
                {
                    throw new AggregateException(errors);
                }
            }
        }

        public SystemCountryCodePoco GetByCode(string code)
        {
            return _repository.GetSingle(c => c.Code == code);
        }

        public  List<SystemCountryCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        //public  SystemCountryCodePoco Get()
        //{

        //    return GetAll().FirstOrDefault();
        //}


        public  void Add(SystemCountryCodePoco[] pocos)
        {
            //foreach (SystemCountryCodePoco poco in pocos)
            //{
            //    if (poco.Id == Guid.Empty)
            //    {
            //        poco.Id = Guid.NewGuid();
            //    }
            //}
            Verify(pocos);

            _repository.Add(pocos);
        }

        public  void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }


    }
}
