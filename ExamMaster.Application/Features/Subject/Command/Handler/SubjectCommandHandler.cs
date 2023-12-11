using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Subject.Command.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subject.Command.Handler
{
    public class SubjectCommandHandler : ResponseHandler,
                                        IRequestHandler<SubjectCreateRequest, Response<string>>
    {

        #region fields
        private readonly IUnitOfWork _subjectCreateRequest;
        #endregion

        #region constracturs
        #endregion

        #region Handlers
        
        public Task<Response<string>> Handle(SubjectCreateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
