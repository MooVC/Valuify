namespace Valuify;

using Valuify.Model;

/// <summary>
/// Defines a contract for source generation in the context of a specific <see cref="Subject"/>.
/// </summary>
internal interface IStrategy
{
    /// <summary>
    /// Triggers the execution of the strategy which may contribute to the output of the generator.
    /// </summary>
    /// <param name="subject">
    /// The subject for which source may be generated.
    /// </param>
    /// <returns>
    /// Zero or more units of <see cref="Source"/> to be output by the generator.
    /// </returns>
    IEnumerable<Source> Generate(Subject subject);
}