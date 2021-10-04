using Data.Dto;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.ObjectValues;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class AtivarUsuarioCommandHandle : IAtivarUsuarioCommandHandle
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AtivarUsuarioCommandHandle(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task Ativar(AtivarUsuarioCommand command)
        {
            var codigo = Convert.ToInt32(await _usuarioRepository.BuscarCodigoDeAtivacao(command.Email));

            if(codigo == command.CodigoDeAtivacao)
            {
                await _usuarioRepository.Ativar(command.Email);
            }
        }
    }
}
