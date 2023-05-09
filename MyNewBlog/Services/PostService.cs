using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using JLBlog.Data;

namespace JLBlog.Services
{
    public class PostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post.Id;
        }

        public async Task<string> SaveImage(IBrowserFile imageFile)
        {
            // Implemente a lógica para salvar a imagem no servidor
            // e retorne o nome do arquivo da imagem (ou o caminho completo)

            // Exemplo simples de salvar a imagem localmente (ajuste de acordo com suas necessidades)
            var path = Path.Combine("wwwroot", "img", "articleMainImages", imageFile.Name);
            using var stream = new FileStream(path, FileMode.Create);
            await imageFile.OpenReadStream().CopyToAsync(stream);

            return imageFile.Name;
        }
    }
}
