using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface ICarService
    {
        void Create(NewCarDTO request);
        List<ToViewCarDTO> GetAll();
        void Update(NewCarDTO request);
        void Delete(NewCarDTO request);
    }
}
