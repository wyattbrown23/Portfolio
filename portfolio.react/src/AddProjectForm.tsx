import * as React from "react";
import { Form } from "./Form";
import { Field } from "./Field";

export const AddProjectForm: React.SFC = () => {
    return (
        <Form
            action="http://localhost:4351/api/contactus"
            render={() => (
                <React.Fragment>
                    <div className="alert alert-info" role="alert">
                        Enter the information below and we'll get back to you as soon as we
                        can.
                    </div>
                    <Field id="title" label="Title" />
                    <Field id="requirements" label="Requirements" editor="multilinetextbox" />
                    <Field id="design" label="Design" />
                    <Field id="completionDate" label="Completion Date" />
                </React.Fragment>
            )}
        />
    );
};

export default AddProjectForm;