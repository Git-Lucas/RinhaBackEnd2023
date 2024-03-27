using Microsoft.AspNetCore.Mvc;
using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.UseCases.CreatePessoa;
using RinhaBackEnd2023.Domain.UseCases.DTOs;

namespace RinhaBackEnd2023.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController(ICreatePessoa createPessoa) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id) 
    {
        return Ok();
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
