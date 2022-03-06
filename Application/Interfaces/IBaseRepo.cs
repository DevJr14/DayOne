using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        /// <summary>
        /// Create a new entry of <see cref="T"/> in db.
        /// </summary>
        /// <param name="item">Object to be created.</param>
        /// <returns>Id of the newly created entry.</returns>
        Task<int> AddAsync(T item);

        /// <summary>
        /// Update an existing entry of <see cref="T"/> in db.
        /// </summary>
        /// <param name="item">Object with values to update those in db with.</param>
        /// <returns>Id of the updated entry.</returns>
        Task<int> UpdateAsync(T item);

        /// <summary>
        /// Delete an existing entry with Id T in db.
        /// </summary>
        /// <param name="id">Id of entry to be deleted.</param>
        /// <returns>Id of the deleted entry.</returns>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// Get an existing entry with Id T in db.
        /// </summary>
        /// <param name="id">Id of entry searched.</param>
        /// <returns>Object <see cref="T"/> from db</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets a list containing <see cref="T"/>.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
    }
}
