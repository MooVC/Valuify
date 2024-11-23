# VALFY01: Type is not compatible with Valuify

<table>
<tr>
  <td>Type Name</td>
  <td>VALFY01_AttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>VALFY01</td>
</tr>
<tr>
  <td>Category</td>
  <td>Usage</td>
</tr>
<tr>
  <td>Severity</td>
  <td>Warning</td>
</tr>
<tr>
  <td>Is Enabled By Default</td>
  <td>Yes</td>
</tr>
</table>

## Cause

A type declaration upon which the `Valuify` attribute is placed is not a `class`.

## Rule Description

A violation of this rule occurs when the `Valuify` attribute is placed on a type declaration that is not a `class`. This occurs most commonly when placed upon a `record` declaration.

For example:

```csharp
[Valuify]
public partial record Example(int Value);
```

## How to Fix Violations

To fix a violation of this rule, determine if the declaration type is correct for the intended usage. If the type is correct, remove the `Valuify` attribute from the declaration, otherwise change the declaration for the type to `class`.

For example:

```csharp
[Valuify]
public partial class Example
{
    public int Value { get; set; }
}
```

or alternatively:

```csharp
public record Example(int Value);
```

## How to Suppress Violations

It is not recommended to suppress the rule. Instead, it is suggested that the usage of the `Valuify` attribute be reevaluated.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable VALFY01 // Type is not compatible with Valuify
[Valuify]
public partial record Example(int Value);
#pragma warning restore VALFY01 // Type is not compatible with Valuify
```

or alternatively:

```csharp
[Valuify]
[SuppressMessage("Design", "VALFY01:Type is not compatible with Valuify", Justification = "Explanation for suppression")]
public partial record Example(int Value);
```

## How to Disable VALFY01

It is not recommended to disable the rule, as this may result in some confusion if the expected equality behavior is not observed.

```ini
# Disable VALFY01: Type is not compatible with Valuify
[*.cs]
dotnet_diagnostic.VALFY01.severity = none
```