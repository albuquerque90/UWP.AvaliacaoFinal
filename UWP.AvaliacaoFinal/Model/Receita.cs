namespace UWP.AvaliacaoFinal.Model
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Define a classe modelo da receita
    /// </summary>
    public class Receita
    {
        #region Properties

        /// <summary>
        /// Gets or sets do id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets do id do tipo da receita.
        /// </summary>
        public virtual Guid TipoReceitaId { get; set; }

        /// <summary>
        /// Gets or sets do título.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets do modo de preparo.
        /// </summary>
        public string ModoPreparo { get; set; }

        /// <summary>
        /// Gets or sets dos ingredientes.
        /// </summary>
        public string Ingredientes { get; set; }

        /// <summary>
        /// Gets or sets do tipo de receita.
        /// </summary>
        [JsonIgnore] 
        public virtual TipoReceita TipoReceita { get; set; }

        #endregion
    }
}
