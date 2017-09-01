package teistermask.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.bindingModel.TaskBindingModel;
import teistermask.entity.Task;
import teistermask.repository.TaskRepository;

import java.util.List;
import java.util.stream.Collectors;

@Controller
public class TaskController {
    private final TaskRepository taskRepository;

    @Autowired
    public TaskController(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        List<Task> allTasks = this.taskRepository.findAll();
        List<Task> openTasks = allTasks.stream()
                .filter(t -> t.getStatus().equals("Open"))
                .collect(Collectors.toList());
        List<Task> inProgressTasks = allTasks.stream()
                .filter(t -> t.getStatus().equals("In Progress"))
                .collect(Collectors.toList());
        List<Task> finishedTasks = allTasks.stream()
                .filter(t -> t.getStatus().equals("Finished"))
                .collect(Collectors.toList());

        model.addAttribute("view", "task/index");
        model.addAttribute("openTasks", openTasks);
        model.addAttribute("inProgressTasks", inProgressTasks);
        model.addAttribute("finishedTasks", finishedTasks);

        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        model.addAttribute("view", "task/create");
        model.addAttribute("task", new Task("", "Open"));
        return "base-layout";
    }

    @PostMapping("/create")
    public String createProcess(Model model, TaskBindingModel taskBindingModel) {

        if (taskBindingModel.getTitle().equals("") ||
                taskBindingModel.getTitle().length() > 30) {
            Task tempTask = new Task(
                    taskBindingModel.getTitle(),
                    taskBindingModel.getStatus()
            );
            model.addAttribute("view", "task/create");
            model.addAttribute("task", tempTask);
            return "base-layout";
        }
        Task newTask = new Task(
                taskBindingModel.getTitle(),
                taskBindingModel.getStatus()
        );
        this.taskRepository.saveAndFlush(newTask);

        return "redirect:/";
    }

    @GetMapping("/edit/{id}")
    public String edit(Model model, @PathVariable int id) {
        Task task = this.taskRepository.findOne(id);

        if (task == null) {
            return "redirect:/";
        }

        model.addAttribute("view", "task/edit");
        model.addAttribute("task", task);
        return "base-layout";
    }

    @PostMapping("/edit/{id}")
    public String editProcess(@PathVariable int id, TaskBindingModel taskBindingModel, Model model) {

        Task taskToEdit = this.taskRepository.findOne(id);

        if (taskBindingModel.getTitle().equals("") ||
                taskBindingModel.getTitle().length() > 30) {
            Task tempTask = new Task(
                    taskBindingModel.getTitle(),
                    taskBindingModel.getStatus()
            );
            tempTask.setId(id);
            model.addAttribute("view", "task/edit");
            model.addAttribute("task", tempTask);
            return "base-layout";
        }
        taskToEdit.setStatus(taskBindingModel.getStatus());
        taskToEdit.setTitle(taskBindingModel.getTitle());
        this.taskRepository.flush();
        return "redirect:/";
    }
}
