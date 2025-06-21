using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Feedback.Data;
using System.Collections.Generic;
using API_Feedback.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedbacksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Feedback> feedbacks = await _context.TB_FEEDBACKS.ToListAsync();
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Feedback f = await _context.TB_FEEDBACKS.FirstOrDefaultAsync(fBusca => fBusca.Id == id);
                if (f == null)
                {
                    return NotFound("Feedback não encontrado.");
                }
                else
                {
                    return Ok(f);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                Feedback fRemover = await _context.TB_FEEDBACKS.FirstOrDefaultAsync(f => f.Id == id);
                if (fRemover == null)
                    return NotFound("Feedback não encontrado.");

                _context.TB_FEEDBACKS.Remove(fRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Feedback feedback)
        {
            try
            {
                
                _context.TB_FEEDBACKS.Update(feedback);

                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Feedback feedback)
        {
            try
            {
                await _context.TB_FEEDBACKS.AddAsync(feedback);
                await _context.SaveChangesAsync();

                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
    }
}
