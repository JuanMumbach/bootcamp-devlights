export interface Task {
    title: string;
    completed: boolean;
    toggleCompleted(): void;
  }