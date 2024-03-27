using Microsoft.AspNetCore.Mvc;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.UseCases.CreatePessoa;
using RinhaBackEnd2023.Domain.UseCases.DTOs;
using RinhaBackEnd2023.Domain.UseCases.Interfaces;

namespace RinhaBackEnd2023.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController(ICreatePessoa createPessoa,
                               IGetPessoa getPessoa) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id) 
    {
        Pessoa pessoa = await getPessoa.ExecuteAsync(id);
        return Ok(pessoa);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePessoaDto createPessoaDto)
    {
        Guid createdGuid = await createPessoa.ExecuteAsync(createPessoaDto);
        
        return CreatedAtRoute(routeName: nameof(GetByIdAsync),
                              value: new { createdGuid });
    }
}
