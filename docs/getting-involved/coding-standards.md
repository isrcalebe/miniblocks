# Introduction

This document outlines the coding standards used in MINIBLOCKS.

While this document may provide guidance on some mechanical formatting issues, whitespace, or other "microscopic details," these are not fixed standards. Always follow the golden rule:

If you are extending, enhancing, or fixing bugs in already implemented code, use the style that's already in use to maintain consistency and easy-to-follow source.

There are some conventions that are not uniformly followed in the codebase (for example, naming conventions). This is because they are relatively new, and much code was written before they were implemented. Our long-term goal is for the entire codebase to adhere to these conventions, but we explicitly do not want patches that perform large-scale reformatting of existing code. On the other hand, it's reasonable to rename methods of a class if you're about to change it in some other way. Confirm these changes separately to facilitate code review.

The ultimate goal of these guidelines is to increase the readability and maintainability of our common source code base.

# Mechanical Source Issues

## Source Code Formatting

### Commenting

Comments play a crucial role in enhancing readability and maintainability. When adding comments, use English prose with appropriate capitalization, punctuation, and so on. Aim to describe the code's purpose and rationale, rather than delving into micro-level details of how it achieves it. Here are a few key aspects to document:

#### File Headers

Each source file is required to include a header with the following content:

```cs
// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT
```

#### Class Overviews

Classes are a fundamental component of an object-oriented project. Therefore, a class definition should include a comment block explaining the purpose of the class and how it operates."

#### Method Information

Documentation for static methods and functions is equally important. A brief explanation of its purpose, together with a description of edge cases, is essential. Readers should understand how to use interfaces without delving into code.

It's useful to address scenarios when the unexpected occurs, such as when a method returns null.

#### Documentation Comments

Documentation comments are used to generate API documentation. They are written in XML and are placed immediately before the item they document. For example:

```cs
/// <summary>
/// Attempts to retrieve a <typeparamref name="T"/> GameBehaviour.
/// </summary>
/// <typeparam name="T">The type of <see cref="GameBehaviour"/> to retrieve.</typeparam>
/// <param name="behaviour">The output parameter to store the retrieved <see cref="GameBehaviour"/>.</param>
/// <returns><c>true</c> if the retrieval was successful, otherwise <c>false</c>.</returns>
/// <example>
/// The following code demonstrates how to use the <see cref="TryGetBehaviour"/> method:
/// <code>
/// if (TryGetBehaviour<TransformBehaviour>(out var transform))
///     transform.Position = Vector3D<float>.Zero;
/// </code>
/// </example>
bool TryGetBehaviour<T>(out T behaviour)
    where T : GameBehaviour
{
}
```

### Using Namespaces

Directly after the file's header comment, there should be a concise list of the `using` *namespaces* employed by the file. We have a preference for arranging these namespaces in the following order:

1. `System` namespaces
2. `MINIBLOCKS` namespaces
3. Third-party namespaces (e.g. `Silk.NET`)

### Source Code Layout

#### Width

Ensure that your code adheres to an 80-column width.

This constraint is essential to facilitate developers' ability to view multiple files side by side in a modest windowed view. While the exact width limit may seem somewhat arbitrary, it's best to adopt a standard. Opting for 90 columns, for instance, wouldn't provide significant benefits and could lead to less appealing code appearance. Additionally, many other projects have already adopted the 80-column convention, and some individuals have configured their editors accordingly (as opposed to using alternative widths like 90 columns).

#### Indentation

Use spaces for indentation instead of tabs. This practice ensures consistent code formatting across various editors and platforms. Maintain a 4-space indentation level, as it aligns with the default setting in many editors and represents the prevalent convention within the C# community.

#### Braces

Braces must be placed on the line following the statement that starts the block.

```cs
if (HasBehaviour<TransformBehaviour>())
{
    // Do something...
}
else
{
    // Do something else...
}
```

### Naming Conventions

#### Use `var` Type Inference to Improve Code Readability

Use `var` type inference when the type of the variable is obvious from the right-hand side of the assignment. For example:

```cs
var transform = new TransformBehaviour();
```

#### Avoid Hungarian Notation

Hungarian notation is a naming convention where variable or function names include hints about their type or intended use. For instance, a variable that stores a count of something might be named `m_count`. However, MINIBLOCKS does not follow this practice. Instead, we prefer to use descriptive names that convey the variable's purpose.

```cs
// Bad, Hungarian notation.
private int m_count;

// Good, descriptive name.
private int count;
```