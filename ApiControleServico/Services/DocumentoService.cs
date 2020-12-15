using ApiControleServico.Data;
using DomainLib.Entidades;

namespace ApiControleServico.Services
{
    public class DocumentoService : ServiceBase<Documento>, IDocumentoService
    {
        public DocumentoService(ApiControleServicoContext dbService) : base(dbService)
        {
        }
    }
}