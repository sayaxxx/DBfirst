using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using AutoMapper;
namespace API.Controllers;
public class DriverController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private  IMapper _mapper;
    public DriverController(IUnitOfWork unitOfWork, IMapper map)
    {
        _unitOfWork = unitOfWork;
        _mapper = map;
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> Guardar(DriverDto ent)
    {
        var mapeo = _mapper.Map<Driver>(ent);
        if (ent == null)
        {
            return BadRequest();
        }
        _unitOfWork.Drivers.Add(mapeo);
        await _unitOfWork.SaveAsync();

        return Ok(ent);
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Drivers.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Drivers.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }



    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Drivers.GetById(id);
        var mapeo = _mapper.Map<DriverDto>(dato);
        if (dato == null)
        {
            return BadRequest();
        }
        return mapeo;
    }



    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> Update(DriverDto entity)
    {
        var mapeo = _mapper.Map<Driver>(entity);
        _unitOfWork.Drivers.Update(mapeo);
        await _unitOfWork.SaveAsync();
        return Ok(entity);
    }
}