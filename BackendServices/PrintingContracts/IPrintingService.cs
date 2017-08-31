// This file is part of AlarmWorkflow.
// 
// AlarmWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AlarmWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AlarmWorkflow.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.ServiceModel;
using AlarmWorkflow.Backend.ServiceContracts.Core;

namespace AlarmWorkflow.BackendService.PrintingContracts
{
    /// <summary>
    /// Defines the exposed interface for the printing service.
    /// </summary>
    [ServiceContract]
    public interface IPrintingService : IExposedService
    {
        /// <summary>
        /// Gets an IEnumerable of printer names of installed printers on this system
        /// </summary>
        /// <returns>A collection of printer names</returns>
        [OperationContract]
        IEnumerable<string> GetPrinters();
    }
}