ALTER TABLE public."SampleTest"
    ADD COLUMN "SpecificationsDone" boolean;

ALTER TABLE public."SampleTest"
    ADD COLUMN "ScheduledDate" time without time zone;

ALTER TABLE public."SampleTestResult"
    ADD COLUMN "MandatoryDone" boolean;
