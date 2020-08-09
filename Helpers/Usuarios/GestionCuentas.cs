using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikc.DAL.Contexts;
using Unikc.DAL.Dto;
using Unikc.DAL.Entities;

namespace UNIKK_API.Helpers.Usuarios
{
    public class GestionCuentas
    {

        private readonly ApplicationDbContext _context;
        public GestionCuentas(ApplicationDbContext pcontext)
        {
            _context = pcontext;
        }

        public bool ActivarUsuario(string email)
        {
            throw new NotImplementedException();
        }

        public bool AutenticarUsuario(string email, string clave)
        {
            bool UsuarioAutenticado = false;
            try
            {
                var usuarioBd = _context.Enterprices.FirstOrDefault(x => x.EmailAdmin == email);

                if (usuarioBd != null)
                {
                    var claveEncriptada = EncriptarClave(clave);

                    if (usuarioBd.PasswordAdmin == claveEncriptada)
                    {
                        UsuarioAutenticado = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return UsuarioAutenticado;
        }

        public bool BloquearUsuario(string email)
        {
            throw new NotImplementedException();
        }

        public string DesEncriptarClave(string cadenaEncroiptada)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaEncroiptada);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string EncriptarClave(string cadenaBlanca)
        {

            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaBlanca);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
