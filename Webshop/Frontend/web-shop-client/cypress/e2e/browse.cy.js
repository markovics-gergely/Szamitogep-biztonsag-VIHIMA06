/* eslint-disable no-undef */
describe('testing browser', () => {
  beforeEach(() => {
    cy.login('Admin', '@Admin1234');
    cy.visit('/browse');
  });

  it('create caff', () => {
    cy.get('[data-cy=add-button]', { timeout: 5000 }).click();
    cy.get('[data-cy=add-form]').should('be.visible');
    cy.wait(200);
    cy.get('[data-cy=add-form] > #title').click().type('CustomTitle').should('have.value', 'CustomTitle');
    cy.wait(200);
    cy.get('[data-cy=add-form] > #description').click().type('Description').should('have.value', 'Description');
    cy.wait(200);
    cy.get('#upload').selectFile('cypress/fixtures/2.caff', { force: true });
    cy.get('#submit').click();
    cy.location('pathname').should('contain', '/browse/');
    cy.visit('/browse');
    cy.get('.caff-title', { timeout: 15000 }).should('contain', 'CustomTitle');
  });

  it('edit caff', () => {
    cy.get('.caff-title', { timeout: 15000 }).contains('CustomTitle').parent().find('#edit').click({force:true});
    cy.get('[data-cy=edit-form]').should('be.visible');
    cy.get('[data-cy=edit-form]').find('#title').should('have.value', 'CustomTitle');
    cy.get('[data-cy=edit-form]').find('#description').should('have.value', 'Description');
    cy.wait(200);
    cy.get('[data-cy=edit-form] > #title').click().clear().type('NewCustomTitle').should('have.value', 'NewCustomTitle');
    cy.wait(200);
    cy.get('#submit').click();
    cy.wait(1000);
    cy.visit('/browse');
    cy.get('.caff-title', { timeout: 15000 }).should('contain', 'NewCustomTitle');
  });

  it('delete caff', () => {
    cy.get('.caff-title', { timeout: 15000 }).contains('NewCustomTitle').parent().find('#delete').click({force:true});
    cy.get('[data-cy=confirm-buttons]').should('be.visible');
    cy.get('[data-cy=confirm-buttons]').find('#accept').should('be.visible').click();
    cy.get('.caff-title', { timeout: 15000 }).should('not.contain', 'NewCustomTitle');
  });

  it('buy caff', () => {
    cy.get('[data-cy=add-button]', { timeout: 5000 }).click();
    cy.get('[data-cy=add-form]').should('be.visible');
    cy.wait(200);
    cy.get('[data-cy=add-form] > #title').click().type('AnotherTitle').should('have.value', 'AnotherTitle');
    cy.wait(200);
    cy.get('[data-cy=add-form] > #description').click().type('Description').should('have.value', 'Description');
    cy.wait(200);
    cy.get('#upload').selectFile('cypress/fixtures/2.caff', { force: true });
    cy.get('#submit').click();
    cy.location('pathname').should('contain', '/browse/');
    cy.visit('/browse');
    cy.get('.caff-title', { timeout: 15000 }).should('contain', 'AnotherTitle');
  
    cy.get('[data-cy=caff-list] > .caff', { timeout: 15000 }).should('have.length.at.least', 1);
    cy.get('.caff-title', { timeout: 15000 }).contains('Title').click({ force: true });
    cy.location('pathname').should('contain', '/browse/');
    cy.get('#buy').click();
    cy.get('[data-cy=confirm-buttons]').should('be.visible');
    cy.get('[data-cy=confirm-buttons]').find('#accept').should('be.visible').click();
    cy.location('pathname').should('contain', '/inventory/');
    cy.get('#back').click();
    cy.get('.caff-title', { timeout: 15000 }).should('contain', 'AnotherTitle');
  });
});
