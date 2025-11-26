# Changelog
All notable changes to Valuify will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# [1.7.2] - 2025-11-26

## Fixed

- Altered HashCode generation to account for positional members.

# [1.7.1] - 2025-11-16

## Fixed

- Static properties are no longer considered as part of equality checks.

# [1.7.0] - 2025-10-17

## Changed

- Reverted **Microsoft.CodeAnalysis.Analyzers** to Version **3.11.0** to maximize compatibility with Visual Studio 2022.
- Reverted **Microsoft.CodeAnalysis.CSharp** to Version **4.0.1** to maximize compatibility with Visual Studio 2022.
- Reverted **Microsoft.CodeAnalysis.CSharp.Workspaces** Version **4.0.1** to maximize compatibility with Visual Studio 2022.
- Reverted **Microsoft.CodeAnalysis.Workspaces.Common** Version **4.0.1** to maximize compatibility with Visual Studio 2022.

# [1.6.0] - 2025-05-17

## Changed

- Updated **Microsoft.CodeAnalysis.Analyzers** to Version **4.14.0** (#33).
- Updated **Microsoft.CodeAnalysis.CSharp** to Version **4.14.0** (#33).
- Updated **Microsoft.CodeAnalysis.CSharp.Workspaces** to Version **4.14.0** (#33).
- Updated **Microsoft.CodeAnalysis.Workspaces.Common** to Version **4.14.0** (#33).

# [1.5.0] - 2025-02-26

## Changed

- Updated **Microsoft.CodeAnalysis.CSharp** to Version **4.13.0** (#24).
- Updated **Microsoft.CodeAnalysis.CSharp.Workspaces** Version **4.13.0** (#24).
- Updated **Microsoft.CodeAnalysis.Workspaces.Common** Version **4.13.0** (#24).

# [1.4.0] - 2025-02-24

## Added

- A new `VALFY05` analyzer which will warn engineers whenever a type inherits from a base that marks `Equals` and/or `GetHashCode` with the `sealed` keyword.

# [1.3.0] - 2025-02-13

## Added

- A new `Ignore` attribute that allows engineers to mark properties that should be disregarded from equality checks (#14).
- A new `VALFY04` analyzer which will warn engineers whenever a property is annotated with the `Ignore` attribute but the `Valuify` attribute is missing from the `class`.

## Changed

- The `VALFY03` analyzer will now disregard properties annotated with `Ignore`.

# [1.2.2] - 2025-01-08

## Fixed

- Valuify will ignore properties that are defined as explicit implementations (#12).

# [1.2.1] - 2025-01-06

## Fixed

- `Object.Equals`, `Object.GetHashCode` and `Object.ToString` overrides are no longer generated if the base seals them (#8).

# [1.2.0] - 2024-12-28

## Changed

- The Equality operator now calls the `IEquatable.Equals` implementation.
- The `IEquatable.Equals` implementation now applies the equality conditions.

## Fixed

- Base properties are now included (#6).
- `Object.Equals`, `Object.GetHashCode` and `Object.ToString` overrides are no longer `sealed` (#7).

# [1.1.0] - 2024-12-12

## Changed

- Updated **Microsoft.CodeAnalysis.CSharp** to Version **4.12.0** (#3).
- Updated **Microsoft.CodeAnalysis.CSharp.Workspaces** Version **4.12.0** (#3).
- Updated **Microsoft.CodeAnalysis.Workspaces.Common** Version **4.12.0** (#3).

# [1.0.0] - 2024-11-23

- Initial Release
