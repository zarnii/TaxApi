using System.Runtime.Serialization;

namespace CarWebApi.DAL.DataBaseExceptions
{
	/// <summary>
	/// Исключение "Запись не найдена."
	/// </summary>
	public class RecordNotFoundException: Exception
	{
		/// <summary>
		/// Конструктор.
		/// </summary>
		public RecordNotFoundException() 
			:base(){ }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="message">Сообщение ошибки.</param>
		public RecordNotFoundException(string? message)
			: base(message) { }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="message">Сообщение ошибкию</param>
		/// <param name="innerException">Вложенное исключение.</param>
		public RecordNotFoundException(string message, Exception? innerException)
			: base(message, innerException) { }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="info">Информация сериализации.</param>
		/// <param name="context">Крнтекст потока сериализации.</param>
		public RecordNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}
