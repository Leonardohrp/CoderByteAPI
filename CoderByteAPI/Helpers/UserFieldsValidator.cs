using CoderByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Helpers
{
    public static class UserFieldsValidator 
    {
        public static void ValidateFields(CreateUser createUser)
        {
            if(string.IsNullOrEmpty(createUser.Name))
                throw new Exception("Nome do usuário em braco ou nulo.");

            if (string.IsNullOrEmpty(createUser.Email))
                throw new Exception("Email do usuário em braco ou nulo.");

            if (!string.IsNullOrEmpty(createUser.Phone))
                createUser.Phone = string.Format("{0:(###) ###-####}", createUser.Phone);

            foreach (var createAddress in createUser.AddressInformations)
            {
                if (string.IsNullOrEmpty(createAddress.Category))
                    throw new Exception("Categoria do usuário em braco ou nulo.");

                if (createAddress.Category != "Residential" && createAddress.Category != "Commercial")
                    throw new Exception("Categoria do usuário deve ser Residental ou Commercial.");

                if (string.IsNullOrEmpty(createAddress.ZipCode))
                    throw new Exception("Cep do usuário em braco ou nulo.");
            }
        }
    }
}
