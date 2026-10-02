# C# / .NET / Unity

## Scope

- Priority: applicable compiler settings / `.editorconfig` → current handwritten file → nearby module files → these rules.
- Before editing, check applicable settings and 2–3 nearby handwritten files. Use syntax supported by the project; ignore vendor/generated code as style references.
- Keep edits focused. Preserve encoding, line endings, existing API names and wiring; no unrelated reformatting or modernization.

## Naming and layout

- `PascalCase`: types, methods, properties, enum members, exposed fields. Interfaces: `I` + `PascalCase`.
- `camelCase`: locals/parameters. `_camelCase`: private fields, including static/serialized fields. Constants: `UPPER_SNAKE_CASE` where established.
- Events/callbacks: `On` + action/state; preserve existing exceptions. Use `Action` / `Action<T>` and `?.Invoke(...)` for optional notifications.
- Preserve `Character.movement`, `dash`, `rigidbody` and local async naming; do not add `Async` mechanically.
- Use 4 spaces, Allman braces, explicit access modifiers except interface members and explicit interface implementations, and spaces around binary operators. Omit redundant `this.`.
- Omit braces for simple single-statement branches/loops; put the body on the next line. Asymmetric braced/unbraced branches are allowed. Brace ambiguous nesting; preserve existing braces. Empty hooks/constructors may use `{ }`.
- Separate logical steps with blank lines; keep related one-line members together.
- Align `=`, `+=`, `-=`, `=>` within short related groups when used nearby.
- Wrap parameters under the first parameter; wrap fluent/LINQ chains one call per line with aligned dots. Prefer leading operators in wrapped conditions/ternaries.
- Put `using` outside namespaces; remove unused imports. No mandatory System-first ordering.
- Use file-scoped namespaces in modern .NET modules, block-scoped namespaces in Unity; preserve existing module style and namespace depth.
- One primary type per matching filename; preserve grouped `Exceptions.cs` and feature-based partial classes. Follow local modifier order.

## C#

- Prefer explicit declared types with target-typed `new()` / `new(args)`. Specify the constructor type when inference is unavailable or ambiguous.
- Prefer explicit primitive types; allow `var` for method results, `foreach`, LINQ/dictionary values and `out var`, following nearby code. Use built-in type keywords.
- Prefer auto-properties and `=>` for simple members/accessors/constructors; use blocks for multi-step logic.
- Use guard clauses, interpolation, `?.`, `??`, `??=`, pattern matching and simple switch/conditional expressions where clear. Follow nullable settings; use `!` only for a known invariant.
- Mark constructor-initialized, unreassigned fields `readonly`; use `readonly struct` for immutable value types. Preserve constructor/static-constructor initialization patterns.
- Prefer method-syntax LINQ; use loops for stateful operations.
- Preserve conventional classes, structs and constructors; do not introduce records, primary constructors or top-level statements solely for modernization.
- Keep methods focused; reuse implementations through forwarding overloads. Preserve explicit interface implementations and protected hooks.
- Preserve dependency injection/registration conventions. Add packages or abstractions only when required by the task.
- Use `Try...` for expected failure and `TryGetValue` for lookups. Preserve domain exceptions; do not copy obsolete serialization boilerplate. No empty catches.
- Use `async` only with awaited work; propagate meaningful cancellation. Preserve UniTask conventions without introducing UniTask into plain .NET.

## Unity

- Put `[SerializeField]` on its own line above private dependency fields.
- Use `[field: SerializeField]` with `public T Name { get; private set; }` for Inspector-backed public data/configuration.
- Preserve public fields in plain data/ECS structs and readonly service data where established.
- Initialize through the existing constructor, `Awake` or injection method. Pair event subscriptions/unsubscriptions at matching lifetime boundaries; use method groups for forwarding handlers.
- Preserve lifecycle callbacks and DI wiring. Use `async void` callbacks only with intentional lifetime/error handling.
- Check Unity/compiler versions before using newer syntax; do not persist compiler configuration by editing generated `.csproj` files.

## Documentation and verification

- Comment non-obvious constraints only; preserve surrounding language. Avoid boilerplate XML documentation.
- Use the existing test harness and naming; test behavior. Keep affected documentation accurate.
- Review the diff and run applicable checks; report checks that could not run.
