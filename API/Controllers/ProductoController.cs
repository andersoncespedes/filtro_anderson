using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ProductoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _map;
    public ProductoController(IUnitOfWork unitOfWork, IMapper map)
    {
        _unitOfWork = unitOfWork;
        _map = map;
    }
    [HttpGet("GetMoreTop")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetMoreTop(){
        var datos = await _unitOfWork.Productos.GetByTop();
        return _map.Map<List<ProductoDto>>(datos);
    }
    [HttpGet("GetMoreThan3000")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductMasIvaDto>>> GetMoreThan3000(){
        var datos = await _unitOfWork.Productos.MoreThan3000();
        return _map.Map<List<ProductMasIvaDto>>(datos);
    }
     [HttpGet("MostSelled")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> MostSelled(){
        var datos = await _unitOfWork.Productos.MostSelled();
        return _map.Map<ProductoDto>(datos);
    }
    [HttpGet("NoPedProd")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NoPedProdDto>>> NoPedProd(){
        var datos = await _unitOfWork.Productos.NoPed();
        return _map.Map<List<NoPedProdDto>>(datos);
    }
}