using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBaseRepo<Request, Response> where Response : class where Request : class
    {
        /// <summary>
        /// Create a new entry of <see cref="Response"/> in db.
        /// </summary>
        /// <param name="item">Object to be created.</param>
        /// <returns>Id of the newly created entry.</returns>
        Task<int> AddAsync(Request item);

        /// <summary>
        /// Update an existing entry of <see cref="Request"/> in db.
        /// </summary>
        /// <param name="item">Object with values to update those in db with.</param>
        /// <returns>Id of the updated entry.</returns>
        Task<int> UpdateAsync(Request item);

        /// <summary>
        /// Delete an existing entry with Id in db.
        /// </summary>
        /// <param name="id">Id of entry to be deleted.</param>
        /// <returns>Id of the deleted entry.</returns>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// Get an existing entry with Id Request in db.
        /// </summary>
        /// <param name="id">Id of entry searched.</param>
        /// <returns>Object <see cref="Request"/> from db</returns>
        Task<Response> GetByIdAsync(int id);

        /// <summary>
        /// Gets a list containing <see cref="Request"/>.
        /// </summary>
        /// <returns></returns>
        Task<List<Response>> GetAllAsync();
    }
}
