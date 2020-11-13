using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.DTO.Comment;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CommentController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Comments
        /// </summary>
        /// <returns></returns>
        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult<IEnumerable<CommentReturnDto>> Get()
        {
            List<Comment> comments = _context.Comments
                .Include(d => d.Blog)
                .Include(u=>u.User).ToList();
            var mapperComments = _mapper.Map<IEnumerable<Comment>,IEnumerable<CommentReturnDto>>(comments);
            return Ok(mapperComments);
        }
     

        /// <summary>
        /// Get Comment from Id
        /// </summary>
        /// <param name="id">for comment</param>
        /// <returns></returns>
        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult<CommentReturnDto> Get(int id)
        {
            Comment comment = _context.Comments.FirstOrDefault(p => p.Id == id);
            if (comment == null) return NotFound();
            var mapperComment = _mapper.Map<Comment, CommentReturnDto>(comment);
            
            return Ok(mapperComment);
        }
        
        /// <summary>
        /// Get Comments by Blog
        /// </summary>
        /// <returns></returns>
        // GET: api/<CommentController>
        [HttpGet("GetCommentsByBlog/{id}")]
        public ActionResult<IEnumerable<CommentReturnDto>> GetCommentsByBlog(int id)
        {
            List<Comment> comments = _context.Comments
                .Include(d => d.Blog)
                .Include(u=>u.User).Where(x=>x.BlogId==id).ToList();
            var mapperComments = _mapper.Map<IEnumerable<CommentReturnDto>>(comments);
            return Ok(mapperComments);
        }

        /// <summary>
        /// Create new Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        // POST api/<CommentController>
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CommentCreateDto commentCreateDto)
        {
            Comment newComment = new Comment
            {
                Context = commentCreateDto.Context,
                BlogId = commentCreateDto.BlogId,
                UserId = commentCreateDto.UserId
            };
          
            await _context.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return Ok(newComment);
        }
        
        

        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Comment dbComment = _context.Comments.FirstOrDefault(p => p.Id == id);
            if (dbComment == null) return NotFound();
            _context.Comments.Remove(dbComment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}