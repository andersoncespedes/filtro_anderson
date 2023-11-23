using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class PedidoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _map;
    public PedidoController(IUnitOfWork unitOfWork, IMapper map){
        _unitOfWork = unitOfWork;
        _map = map;
    }
    [HttpGet("NotOnTime")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DtoPedido1>>> NotOnTime(){
        var dato = await _unitOfWork.Pedidos.NotOnTime();
        return _map.Map<List<DtoPedido1>>(dato);
    }

}