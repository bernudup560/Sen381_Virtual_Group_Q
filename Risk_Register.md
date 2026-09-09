This document tracks project-specific risks and their downstream consequences. Risks are prioritized to ensure the engineering baseline remains controlled despite schedule, resource, or scope constraints.
R-01: Scope Creep / Unauthorized Feature Additions
•	Risk Description: Stakeholders may request major new features after the Milestone 1 baseline is signed off, threatening the fixed project schedule.
•	Probability: High
•	Impact: High
•	Priority: High
•	Mitigation Strategy (Preventative): Enforce the defined Scope Baseline using the MoSCoW framework. Require formal GitHub issue tracking for any new requests. 
•	Contingency Plan (Reactive): If forced to accept a new feature, initiate a formal trade-off analysis to drop a currently planned and less important feature of equal size.
•	Owner: Bernu
•	Status: Active
R-02: Undersized Team Constraint
•	Risk Description: The project baseline expects a standard team, but we are operating with a reduced 2-person team split managing a 3-person workload.
•	Probability: High
•	Impact: Medium
•	Priority: Medium
•	Mitigation Strategy (Preventative): Formal exemption for the team size and the two-reviewer GitHub constraint was requested and officially granted by the lecturer. Proceeding with strict modular decoupling so Requirements work and Engineering Controls proceed in parallel. 
•	Contingency Plan (Reactive): Adjust the scope baseline downward to account for a 33% reduction in workforce if the workload becomes unmanageable before the Milestone 2 deadline.
•	Owner: Rodney
•	Status: Mitigated (Exemption Granted)
R-03: Data Privacy / Security Compliance
•	Risk Description: Handling citizen location data and personal contact information introduces security vulnerabilities if the future Milestone 2 architecture does not enforce proper multi-tenant role separation. 
•	Probability: Medium
•	Impact: High
•	Priority: Medium
•	Mitigation Strategy (Preventative): Identify security constraints early in Milestone 1. Log centralized RBAC middleware as a critical Forward Engineering Consideration. 
•	Contingency Plan (Reactive): If a data leak risk is identified during construction, halt development on that feature until JWT or session cookie protocols are audited. 
•	Owner: Bernu
•	Status: Active
R-04: R0 Budget Limit and Free-Tier Hosting Constraints
•	Risk Description: The project has a strict R0 budget. If the selected database or backend framework exceeds free-tier limits, the system will experience unauthorized costs or experience downtime. 
•	Probability: Medium
•	Impact: High
•	Priority: High
•	Mitigation Strategy (Preventative): Design database schemas to fit within free-tier row limits and implement warm-up pings to prevent server instance sleep latency spikes. 
•	Contingency Plan (Reactive): If limits are reached during development, switch to a local-only deployment for the final demonstration.
•	Owner: Bernu
•	Status: Active
