using Telemetrix.API.Context;
using Telemetrix.API.Model;
using Telemetrix.API.Model.DTOs;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Telemetrix.API.Service
{
    public interface IAutenticacaoService
    {
        Usuario ValidarCredenciais(UsuarioDTO usuarioDto);
        Usuario ValidarCredenciais(string username);
        Usuario AtualizarRefreshToken(UsuarioDTO usuarioDTO);
        Usuario AtualizarRefreshToken(Usuario usuario);
    }
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly MetasContext _metasContext;

        public AutenticacaoService(MetasContext metasContext)
        {
            _metasContext = metasContext;
        }

        public Usuario AtualizarRefreshToken(UsuarioDTO usuarioDTO)
        {
            if (!_metasContext.Usuarios.Any(u => u.Id.Equals(usuarioDTO.Id))) return null;

            var result = _metasContext.Usuarios.SingleOrDefault(p => p.Id.Equals(usuarioDTO.Id));

            if(result != null)
            {
                try
                {
                    _metasContext.Entry(result).CurrentValues.SetValues(usuarioDTO);
                    _metasContext.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }

        public Usuario AtualizarRefreshToken(Usuario usuario)
        {
            if (!_metasContext.Usuarios.Any(u => u.Id.Equals(usuario.Id))) return null;

            var result = _metasContext.Usuarios.SingleOrDefault(p => p.Id.Equals(usuario.Id));

            if (result != null)
            {
                try
                {
                    _metasContext.Entry(result).CurrentValues.SetValues(usuario);
                    _metasContext.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }

        public Usuario ValidarCredenciais(UsuarioDTO usuarioDto)
        {
            var pwd = ComputeHash(usuarioDto.Senha, new SHA256CryptoServiceProvider());
            return _metasContext.Usuarios.FirstOrDefault( x => (x.Username == usuarioDto.Username) && x.Senha == pwd);
        }

        public Usuario ValidarCredenciais(string username)
        {
            return _metasContext.Usuarios.SingleOrDefault(u => (u.Username == username));
        }

        private string ComputeHash(string senha, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(senha);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
