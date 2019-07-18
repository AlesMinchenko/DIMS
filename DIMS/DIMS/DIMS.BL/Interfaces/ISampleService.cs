using HIMS.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Interfaces
{
    public interface ISampleService : IGetEntries
    {
        SampleDTO GetSample(int? id);
        IEnumerable<SampleDTO> GetSamples();
        void UpdateSample(SampleDTO sampleDTO);
        void DeleteSample(int? id);
        void SaveSample(SampleDTO sampleTM);
        void Dispose();
    }
}
