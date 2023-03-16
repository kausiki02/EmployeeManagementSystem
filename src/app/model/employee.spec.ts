import { Employee } from './employee';

describe('Employee', () => {
  it('should create an instance', () => {
    expect(new Employee()).toBeTruthy();
  });
});
import { CreateEmployee } from './employee';

describe('CreateEmployee', () => {
  it('should create an instance', () => {
    expect(new CreateEmployee()).toBeTruthy();
  });
});