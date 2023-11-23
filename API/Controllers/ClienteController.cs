using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ClienteController : BaseApiController
{
     private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _map;

    public ClienteController(IUnitOfWork unitOfWork, IMapper map){
        _unitOfWork = unitOfWork;
        _map = map;
    }
    [HttpGet("GetNoPaid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Cliente2dto>>> GetNoPaid(){
        var datos = await _unitOfWork.Clientes.GetNoPagos();
        return _map.Map<List<Cliente2dto>>(datos);
    }
     [HttpGet("GetByPed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetByPed(){
        var datos = await _unitOfWork.Clientes.GetAllAsync();
        return _map.Map<List<ClienteDto>>(datos);
    }
     [HttpGet("GetWithEmp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteWithEmpDto>>> GetWithEmp(){
        var datos = await _unitOfWork.Clientes.GetAllAsync();
        return _map.Map<List<ClienteWithEmpDto>>(datos);
    }
}
