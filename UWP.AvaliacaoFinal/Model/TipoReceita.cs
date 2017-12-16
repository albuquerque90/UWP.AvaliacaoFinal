namespace UWP.AvaliacaoFinal.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define a classe modelo tipo de receita.
    /// </summary>
    public class TipoReceita
    {
        #region Properties

        /// <summary>
        /// Gets or sets do id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets da descrição.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Gets or sets a coleção de receitas associadas.
        /// </summary>
        public virtual ICollection<Receita> Receitas { get; set; }

        #endregion
    }
}
