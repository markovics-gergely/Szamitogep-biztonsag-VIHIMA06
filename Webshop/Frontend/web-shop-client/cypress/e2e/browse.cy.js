/* eslint-disable no-undef */
describe('testing browser', () => {
  beforeEach(() => {
    cy.login('Admin', '@Admin1234');
    cy.visit('/browse');
  });

  it('click caff', () => {
    cy.get('[data-cy=caff-list] > .caff', { timeout: 15000 }).should('have.length.at.least', 1);
    cy.get('[data-cy=caff-list] > .caff').first().click();
    cy.location('pathname').should('contain', '/browse/');
  });
});
