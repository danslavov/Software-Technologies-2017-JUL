package todolist.bindingModel;

import javax.validation.constraints.NotNull;

public class TaskBindingModel {

    @NotNull
    public String getTitle() {
        return this.title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @NotNull
    public String getComments() {
        return this.comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }

    private String title;

    private String comments;

}
