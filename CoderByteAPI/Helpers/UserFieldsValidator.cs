using CoderByteAPI.Models;
using CoderByteAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Helpers
{
    public static class UserFieldsValidator 
    {
        public static void ValidateCreateUserFields(CreateUser createUser)
        {
            if(string.IsNullOrEmpty(createUser.Name))
                throw new Exception("Nome do usuário em braco ou nulo.");

            if (string.IsNullOrEmpty(createUser.Email))
                throw new Exception("Email do usuário em braco ou nulo.");

            if (!string.IsNullOrEmpty(createUser.Phone))
                createUser.Phone = string.Format("{0:(##) #####-####}", createUser.Phone);

            foreach (var createAddress in createUser.AddressInformations)
            {
                if (string.IsNullOrEmpty(createAddress.Categoria.ToString()))
                    throw new Exception("Categoria do usuário em braco ou nulo.");

                if (Enum.IsDefined(typeof(CategoryEnum), createAddress.Categoria) == false)
                    throw new Exception("Categoria do usuário deve ser Residential ou Commercial. Use 0 para Residential e 1 para Commercial.");

                if (string.IsNullOrEmpty(createAddress.ZipCode))
                    throw new Exception("Cep do usuário em braco ou nulo.");
            }
        }
    }
}
