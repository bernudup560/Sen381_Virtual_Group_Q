This document records genuine Milestone 1 engineering decisions already made, alongside justified deferments where evidence is not yet sufficient.
DEC-01: Adoption of Markdown for Initial Documentation Baseline
•	Date: 2026-09-09
•	Topic: Project Documentation Format
•	Options Considered: Microsoft Word (.docx), PDF exports, and Markdown (.md) inside GitHub.
•	Justification: Markdown ensures seamless version control tracking, inline code styling, and direct integration with GitHub's pull request review interface, satisfying the project standards.
•	Status: Approved / Finalized
DEC-02: Deferment of Final Technology Stack Selection
•	Date: 2026-09-09
•	Topic: Backend Framework and Database Selection
•	Options Considered: Node.js/Express with MongoDB vs. Java or C# with PostgreSQL.
•	Justification / Missing Evidence: M1 is an engineering foundation milestone, and final technology selection is explicitly out-of-scope. The team has intentionally deferred this choice until requirements are fully analyzed to ensure the chosen stack can meet the strict R0 budget limit and sub-2.0 second query latency constraint defined in the PED. 
•	Status: Deferred
