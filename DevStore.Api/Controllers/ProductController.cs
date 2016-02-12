using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DevStore.Database.DataContexts;
using DevStore.Domain;

namespace DevStore.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1")]
    public class ProductController : ApiController
    {
        private readonly DataContext _context = new DataContext();

        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            var result = _context.Products.Include("Category").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            var result = _context.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetProductsByCategories(int categoryId)
        {
            var result = _context.Products.Include("Category").Where(x => x.CategoryId == categoryId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProducts(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto");
            }

        }

        [HttpPatch]
        [Route("products")]
        public HttpResponseMessage PatchProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _context.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }

        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _context.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }

        [HttpDelete]
        [Route("products")]
        public HttpResponseMessage DeleteProduct(int productId)
        {
            if (productId < 1)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _context.Products.Remove(_context.Products.Find(productId));
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir produto");
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}