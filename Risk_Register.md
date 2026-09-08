CivicConnect Risk Register

This document tracks project-specific risks and their downstream consequences. Risks are prioritized to ensure the engineering baseline remains controlled despite schedule, resource, or scope constraints.

R-01: Scope Creep / Unauthorized Feature Additions
Stakeholders may request major new features after the M1 baseline is signed off, threatening the fixed project schedule.
* Probability:High
* Impact: High
* Priority: High
* Mitigation Strategy (Preventative): Strictly enforce the defined Scope Baseline and out-of-scope exclusions. Require formal GitHub issue tracking for any new requests.
* Contingency Plan (Reactive): If forced to accept a new feature, initiate a formal trade-off analysis to drop a currently planned feature of equal size to protect the deadline.
* Owner: Bernu
* Status: Active

R-02: Undersized Team Constraint
The project brief strictly mandates a team size of exactly 3 students[cite: 1], but the team currently operates with 2 members. This heavily impacts delivery speed and breaks the two-reviewer GitHub constraint[cite: 1].
* Probability: High
* Impact: High
* Priority: Critical
* Mitigation Strategy (Preventative): Immediately notify the lecturer to seek a formal exemption for the two-reviewer GitHub rule and the team size constraint.
* Contingency Plan (Reactive): Adjust the scope baseline downward to account for a 33% reduction in workforce, pending lecturer approval.
* Owner: Rodney
* Status: Active

R-03: Data Privacy / Security Compliance
Handling citizen location data and personal contact information introduces security vulnerabilities if the future M2 architecture does not enforce proper encryption.
* Probability: Medium
* Impact: High
* Priority: Medium
* Mitigation Strategy (Preventative): Identify security constraints early in M1. Log data encryption as a critical Forward Engineering Consideration before deciding on the database schema.
* Contingency Plan (Reactive): If a data leak risk is identified during construction, halt development on that feature until security protocols are audited and fixed.
* Owner: Bernu
* Status: Active

R-04: Delayed Technology Stack Decisions
Delays in finalizing the backend framework or database selection could compress the time available for actual construction in M2.
* Probability: Medium
* Impact: Medium
* Priority: Medium
* Mitigation Strategy (Preventative): Formally record deferred decisions in the M1 Decision Log with strict deadlines for when the missing evidence must be gathered.
* Contingency Plan (Reactive): Select the team's most familiar technology stack by default if the research deadline is missed to ensure coding begins on time.
* Owner: Rodney
* Status: Active
