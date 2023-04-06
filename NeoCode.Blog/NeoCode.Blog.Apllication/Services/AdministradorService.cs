using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NeoCode.Blog.Apllication.Contracts.Services;
using NeoCode.Blog.Apllication.DTO.Administrador;
using NeoCode.Blog.Apllication.DTO.Auth;
using NeoCode.Blog.Core.Exceptions;
using NeoCode.Blog.Domain.Contracts.Repositories;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Apllication.Services;

public class AdministradorService : IAdministradorService
{
    private readonly IMapper _mapper;
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IPasswordHasher<Administrador> _passwordHasher;

    public AdministradorService(IMapper mapper, IAdministradorRepository administradorRepository, IPasswordHasher<Administrador> passwordHasher)
    {
        _mapper = mapper;
        _administradorRepository = administradorRepository;
        _passwordHasher = passwordHasher;
    }
    
    public Task<AdministradorDto> ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<AdministradorDto> Adicionar(AdministradorDto administradorDto)
    {
        var administradorExist = await _administradorRepository.GetByEmail(administradorDto.Email);

        if (administradorExist != null)
        {
            throw new DomainExceptions("Já existe um usuário cadastrado com o email informado.");
        }

        var administrador = _mapper.Map<Administrador>(administradorDto);
        administrador.Senha = _passwordHasher.HashPassword(administrador, administrador.Senha);
        administrador.Validate(); //validação de dominio

        var admCreated = await _administradorRepository.Create(administrador);

        return _mapper.Map<AdministradorDto>(admCreated);
    }

    public async Task<AdministradorDto> Editar(AdministradorDto administradorDto)
    {
        var administradorExist= await _administradorRepository.GetById(administradorDto.Id);

        if (administradorExist == null)
        {
            throw new DomainExceptions("Não existe administrador com o Id informado.");
        }

        var administrador = _mapper.Map<Administrador>(administradorDto);
        administrador.Senha = _passwordHasher.HashPassword(administrador, administrador.Senha);
        administrador.Validate();

        var administradorUpdate = await _administradorRepository.Update(administrador);

        return _mapper.Map<AdministradorDto>(administradorUpdate);
    }

    public async Task Excluir(int id)
    {
        var administradorExist = await _administradorRepository.GetById(id);

        if (administradorExist == null)
        {
            throw new DomainExceptions("Não existe administrador com o Id informado.");
        }

        await _administradorRepository.Remove(id);
    }
    
    private static string GenerateToken(Administrador administrador)
    {
        string secret = "dGVzdGV0ZXN0ZXRlc3RldGVzdGV0ZXN0ZXRlc3Rl";
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Id", administrador.Id.ToString()),
                new Claim(ClaimTypes.Email, administrador.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public async Task<AuthenticateAdministradorDto> Authenticade(LoginDto loginDto)
    {
        var administrador = await _administradorRepository.GetByEmail(loginDto.Email);
        if (administrador == null)
        {
            throw new DomainExceptions("A combinação de usuário e senha está incorreta");
        }

        var result = _passwordHasher.VerifyHashedPassword(administrador, administrador.Senha, loginDto.Password);
        if (result == null)
        {
            throw new DomainExceptions("A combinação de usuário e senha está incorreta");
        }
        
        //gerando o jwt
        return new AuthenticateAdministradorDto()
        {
            Id = administrador.Id,
            Email = administrador.Email,
            Token = GenerateToken(administrador)
        };
    }
}